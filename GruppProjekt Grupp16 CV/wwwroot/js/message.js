function ConfirmWindow(box, open) {
    document.getElementById(box).style = "visibility:"+(open ? "visible" : "hidden");
    document.getElementById("cover-sheet").style = "visibility:"+(open ? "visible" : "hidden");
}

document.getElementById("confirm-sent-message").addEventListener("click", function () {
    ConfirmWindow("confirm-box-sent-message", true)
});

document.getElementById("no-confirm-sent-message").addEventListener("click", function () {
    ConfirmWindow("confirm-box-sent-message", false)
});

document.getElementById("confirm-unread-message").addEventListener("click", function () {
    ConfirmWindow("confirm-box-unread-message", true)
});

document.getElementById("no-confirm-unread-message").addEventListener("click", function () {
    ConfirmWindow("confirm-box-unread-message", false)
});

document.getElementById("confirm-read-message").addEventListener("click", function () {
    ConfirmWindow("confirm-box-read-message", true)
});

document.getElementById("no-confirm-read-message").addEventListener("click", function () {
    ConfirmWindow("confirm-box-read-message", false)
});