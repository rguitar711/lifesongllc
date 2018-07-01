function playSong() {
    //$(".song").unbind().click(function () {
    //$(".song").off('click').on('click', function () {
       // $(".song").on('click', function () {

    $(".song").click(function () {
            //this is the url
            var url = $(this).attr("data-song");
           
        var audio = $("#audioPlayer")[0];
        var title = $(this).html();
        $("#trackname").text(title);
        //if (audio.paused) {
        //    audio.src = url;
        //    audio.play();
        //} else {
        //    audio.pause();
        //    //audio.currentTime = 0;
        //}

        audio.src = url;
        audio.play();
      
    });
   
   

}

//function play() {
//    $(".song").click(function () {
//        var url = $(this).attr("data-song");
//        var audio = $("#audioPlayer")[0];
//        audio.src = url;
//        audio.play();

//    })
//}

//function changeRowColor() {
//    $('#trackTable tbody tr').click(function () {
//        $(this).addClass('bg-success').siblings().removeClass('bg-success');
//    });
//}
//function play() {

//    //var audio = document.getElementById("audioPlayer");
//    $(".song").click(function () {
//        var url = $("#playbutton").attr("data-song");
//        alert(url);
//    });
    //var x = document.getElementById(".song");
    //if (audio.paused) {
    //    var url = x.attr("data-song");
    //    alert(url);
    //    audio.src = url;
    //    audio.play();

    //} else {
    //    audio.pause();
    //    audio.currentTime = 0;
    //}
//}


