var oPopup = document.getElementsByClassName('popup')[0];
var oA = document.querySelectorAll(".popup a");
var timer;
var iSpeed = 20; //速度
oPopup.style.right = '-350px';


//不管是通过还是拒绝都会关闭此窗口
oA.forEach(function (ele,index) {
    ele.onclick = function () {
        this.parentNode.style.display = "none";
    }
})


oPopup.onmouseover = function () {
    startMove(this, 1);
}

oPopup.onmouseout = function () {
    startMove(this,0)
}

function startMove(obj, iTarget) {
    clearInterval(timer);
    timer = setInterval(function () {
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
