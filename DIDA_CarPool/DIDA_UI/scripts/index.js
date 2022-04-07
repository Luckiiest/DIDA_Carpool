////const { data } = require("jquery");

//百度地图
function search(start,end) {
    var map = new BMap.Map('allmap'); // 创建Map实例

    map.enableScrollWheelZoom(true);     //开启鼠标滚轮缩放

    map.centerAndZoom(new BMap.Point(116.404, 39.915), 11);// 初始化地图,设置中心点坐标和地图级别

    const driving = new BMap.DrivingRoute(map, { renderOptions: { map: map, autoViewport: true } });
    driving.search(start, end);

}

function mySearch() {
    //添加地图类型控件
    var map = new BMap.Map("allmap"); // 创建Map实例
    map.centerAndZoom(new BMap.Point(116.404, 39.915), 11); // 初始化地图,设置中心点坐标和地图级别
    //添加地图类型控件
    map.addControl(
        new BMap.MapTypeControl({
            mapTypes: [BMAP_NORMAL_MAP, BMAP_HYBRID_MAP],
        })
    );

    map.centerAndZoom(new BMap.Point(116.404, 39.915), 11);  // 初始化地图,设置中心点坐标和地图级别
    map.enableScrollWheelZoom(true);
}

$(".search-city").on("click", function () {
    const start = $(".open-city-input").val();
    const end = $(".close-city-input").val();
    search(start, end);
})

// 关闭
$(".close").on('click',function(e) {
    $('.release-container').css("display",'none');
    $(".user-detail").css("display","none")
})


// 点击发布信息
$(".release-long-distance").on("click",function(e) {
    e.preventDefault();
    // console.log('1');
    $('.release-container').css("display",'block');
})

$(".back").on("click", function () {
    goBack();
})

function goBack() {
    window.history.back();
}

$(function () {
    mySearch();
    // search();
    // sea();
});
