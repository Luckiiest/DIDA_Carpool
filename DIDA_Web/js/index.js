//百度地图
function search() {
  var start = document.getElementById('open-city-input').value,
    end = document.getElementById('close-city-input').value
  //添加地图类型控件
  var map = new BMap.Map('allmap') // 创建Map实例
  map.centerAndZoom(new BMap.Point(116.404, 39.915), 11) // 初始化地图,设置中心点坐标和地图级别

  var driving = new BMap.DrivingRoute(map, { renderOptions: { map: map, autoViewport: true } })
  driving.search(start, end)
  map.enableScrollWheelZoom(true)
}

function mySearch() {
  //添加地图类型控件
  var map = new BMap.Map('allmap') // 创建Map实例
  map.centerAndZoom(new BMap.Point(116.404, 39.915), 11) // 初始化地图,设置中心点坐标和地图级别
  //添加地图类型控件
  map.addControl(
    new BMap.MapTypeControl({
      mapTypes: [BMAP_NORMAL_MAP, BMAP_HYBRID_MAP],
    })
  )
  map.setCurrentCity('北京') // 设置地图显示的城市 此项是必须设置的
  map.enableScrollWheelZoom(true)
}

// 搜索线路
$('.search-line').on('click', function (e) {
  try {
    search()
  } catch {
    mySearch()
  }
  // console.log(1);
})

// 关闭
$('.close').on('click', function (e) {
  $('.release-container').css('display', 'none')
  $('.user-detail').css('display', 'none')
})

// 点击发布信息
$('.release-long-distance').on('click', function (e) {
  e.preventDefault()
  // console.log('1');
  $('.release-container').css('display', 'block')
})


$(function () {
  mySearch()
  // search();
  // sea();
})
