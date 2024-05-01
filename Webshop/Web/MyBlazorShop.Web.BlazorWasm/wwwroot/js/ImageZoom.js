function zoomin() {
    var myImg = document.getElementById("zoom_img");
    var currWidth = myImg.clientWidth;

    myImg.style.width = (currWidth + 100) + "px";
}

function zoomout() {
    var myImg = document.getElementById("zoom_img");
    var currWidth = myImg.clientWidth;

    myImg.style.width = (currWidth - 100) + "px";
}