$(function () {

    var msg = $.connection.msg;

    msg.client.sendMessage = function(name, text,photoId) {
        $(".scroll").append('<div class="mailto">'+
                       '<p>'+text+
                       ' </p>'+
                       '<img src="/Profile/GetImage?PhotoId='+photoId+'" alt="' + name + '" width="150" height="150" />' +
                    '</div>');

    }



        $.connection.hub.start().done(function () {

        });

});