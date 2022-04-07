--创建存储过程pass_application，用于车主申请通过验证
--申请通过操作
-- exec pass_application '27','36','0','1'
IF
	EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = object_id( 'pass_application' ) ) DROP PROCEDURE pass_application 
GO
	CREATE PROCEDURE pass_application ( @lineID INT, --线路ID
		@userID VARCHAR ( 10 ), --用户ID
		@showOrLong INT, --长途Or短途
		@status VARCHAR ( 10 ) --状态
		) AS BEGIN TRANSACTION -- 获取lineMembers中是否存在此线路
	SELECT
		* 
	FROM
		LineMembers 
	WHERE
		LineID =@lineID 
		AND ShowOrLong =@showOrLong
	IF
		@@ROWCOUNT <= 0 BEGIN--是否插入成员表成功
			INSERT INTO LineMembers ( LineID, ShowOrLong, Members )
		VALUES
			( @lineID,@showOrLong,@userID )
		IF
			@@ERROR <= 0 BEGIN--更改申请表中申请状态
				UPDATE Application 
				SET Status =@status 
			WHERE
				lineID =@lineID 
				AND UserID =@userID 
				AND ShowOrLong =@showOrLong
			IF
				@@ERROR <= 0 BEGIN--申请线路通过之后更改已通过人数
				IF
					@showOrLong = '0' BEGIN--长途更改通过人数
						UPDATE LongInfo 
						SET NumberParticipants = NumberParticipants + 1 
					WHERE
						ID =@lineID
					IF
						@@ERROR <= 0 COMMIT TRANSACTION ELSE ROLLBACK TRANSACTION 
						END --短途更改通过人数
					ELSE
					IF
						@showOrLong = '1' BEGIN
							UPDATE ShowInfo 
							SET NumberParticipants = NumberParticipants + 1 
						WHERE
							ID =@lineID
						IF
							@@ERROR <= 0 COMMIT TRANSACTION ELSE ROLLBACK TRANSACTION 
						END 
					END ELSE ROLLBACK TRANSACTION 
				END ELSE ROLLBACK TRANSACTION 
					END ELSE BEGIN--如果该线路已经有人申请过，则更改添加线路成员
					UPDATE LineMembers 
					SET Members = Members + '、' + @userID 
				WHERE
					LineID = @lineID 
					AND ShowOrLong = showOrLong
				IF
					@@ERROR <= 0 BEGIN--更改申请表中申请状态
						UPDATE Application 
						SET Status =@status 
					WHERE
						lineID =@lineID 
						AND UserID =@userID 
						AND ShowOrLong =@showOrLong
					IF
						@@ERROR <= 0 BEGIN--申请线路通过之后更改已通过人数
						IF
							@showOrLong = '0' BEGIN--长途更改通过人数
								UPDATE LongInfo 
								SET NumberParticipants = NumberParticipants + 1 
							WHERE
								ID =@lineID
							IF
								@@ERROR <= 0 COMMIT TRANSACTION ELSE ROLLBACK TRANSACTION 
								END --短途更改通过人数
							ELSE
							IF
								@showOrLong = '1' BEGIN
									UPDATE ShowInfo 
									SET NumberParticipants = NumberParticipants + 1 
								WHERE
									ID =@lineID
								IF
									@@ERROR <= 0 COMMIT TRANSACTION ELSE ROLLBACK TRANSACTION 
								END 
							END ELSE ROLLBACK TRANSACTION 
						END ELSE ROLLBACK TRANSACTION 
END 