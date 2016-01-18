Status = {
    Like: "like",
    Dislike: "dislike"
}

Classes = {
    Like: "like",
    NotLike: "not_like"
}


function pressLike(id) {
    var status = document.getElementById(id);
    var btn = document.getElementById(id+"-button");
    if (status.value == Status.Dislike) {
        btn.classList.remove(Classes.Like)
        btn.classList.add(Classes.NotLike)
        status.value = Status.Like
    }
    else if (status.value == Status.Like) {
        btn.classList.remove(Classes.NotLike)
        btn.classList.add(Classes.Like)
        status.value = Status.Dislike
    }
}