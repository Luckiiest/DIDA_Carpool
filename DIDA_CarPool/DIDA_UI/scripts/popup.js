var oPopup = document.getElementsByClassName('popup');
var oClose = document.querySelector(".popup .close");
var timer;
var iSpeed = 20; //速度

for (var i = 0; i < oPopup.length; i++) {
    oPopup[i].style.right = '-350px';
}


for (let i = 0; i < oPopup.length; i++) {
    oPopup[i].onmouseover = function () {
        startMove(this, 1);
    }
}

for (let i = 0; i < oPopup.length; i++) {
    oPopup[i].onmouseout = function () {
        startMove(this, 0);
    }
}

//不管是通过还是拒绝都会关闭此窗口
oClose.onclick = function () {
    this.parentNode.style.display = "none";
}

// 运动函数
function startMove(obj, iTarget) {
    clearInterval(obj.timer);
    obj.timer = setInterval(function () {
        if (iTarget) {
            obj.style.right = parseFloat(obj.style.right) + iSpeed + 'px';
            if (parseFloat(obj.style.right) >= 0) {
                obj.style.right = '0';
                clearInterval(timer);
            }
        } else {
            obj.style.right = parseFloat(obj.style.right) - iSpeed + 'px';
            if (parseFloat(obj.style.right) <= -350) {
                obj.style.right = '-350px';
                clearInterval(timer);
            }
        }
    }, 30);
}
