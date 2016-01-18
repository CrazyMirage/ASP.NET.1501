function OnLoadComment(data) {
    if (data != null) {
        var last = document.getElementById('last');
        var result = $("#comment-result");
        for (var i = 0; i < data.length; i++) {
            var date = new Date(parseInt(data[i].CreatedDateTime.substr(6)));
            result.append("<div class='comment'>" +
                                "<div class='detail'>" +
                                    data[i].Author + 
                                        "<span style='float:right'>" +
                                             date.toDateString() +
                                        "</span>"+
                                "</div>" +
                                "<div class='comment-text'>" +
                                    data[i].Text +
                                "</div>" +
                         "</div>");

        }
        last.value = data.length + parseInt(last.value);
    }
}