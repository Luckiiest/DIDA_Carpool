$(document).ready(function () {
    // 将tab内容隐藏
    $('.menu-content').hide();
    // 给tab第一个标签添加active，特有属性
    $('.menu-list:first').addClass('active');
    // 给tab第一个内容显示
    $('.menu-content:first').show();

    // 给tab标签添加click点击事件
    $('.menu-list').on('click', function () {
        $('.menu-list').removeClass('active');
        $(this).addClass("active");
        // 将tab内容全部隐藏
        $('.menu-content').hide();
        // 获取this下面a标签的href标签中的id
        var activeTab = $(this).find('a').attr('href');
        console.log($(this));
        // 将Id所属的标签显示
        $(activeTab).fadeIn();
        return false;
    });
});