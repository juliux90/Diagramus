
function connect() {
    //try {
    //    var socket;
    //    var host = "ws://localhost:17438/home/getelement";
    //    var socket = new WebSocket(host);

    //    console.log('Socket Status: ' + socket.readyState);

    //    socket.onopen = function () {
    //        console.log('Socket Status: ' + socket.readyState + ' (open)');
    //    }

    //    socket.onmessage = function (msg) {
    //        console.log('Received: ' + msg.data);
    //    }

    //    socket.onclose = function () {
    //        console.log('Socket Status: ' + socket.readyState + ' (Closed)');
    //    }

    //    socket.onerror = function () {
    //        console.log('Socket Error: ' + socket.readyState + ' (Closed)');
    //    }

    //} catch (exception) {
    //    console.log('Error' + exception);
    //}

    var jsonUrl = "home/getelement";
    $.getJSON(
        jsonUrl,
        function (json) {
            console.log(json);
        }
    );
}

$(document).ready(function() {  
    if (!("WebSocket" in window)) {
        $('<p>Oh no, you need a browser that supports WebSockets. How about <a href="http://www.google.com/chrome">Google Chrome</a>?</p>').appendTo('body');
    } else {

        //The user has WebSockets
        document.getElementById("testact").onclick = connect;
    }
});  