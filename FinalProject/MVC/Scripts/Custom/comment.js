function OnLoadComment(data) {
    var last = document.getElementById('last');
    var result = $("#comment-result");
    for (var i = 0; i < data.length; i++) {
        result.append("<div class='comment'>" + 
                            "<div class='detail'>" + 
                                data[i].Author + " " + data[i].CreatedDateTime + 
                            "</div>" + 
                            "<div class='comment-text'>" + 
                                data[i].Text +
                            "</div>"+
                     "</div>")
    }
    last.value = data.length + parseInt(last.value);
}