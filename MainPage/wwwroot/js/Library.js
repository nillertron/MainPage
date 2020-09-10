function ToggleModal() {
    $('#modal').modal({
        show: 'true'
    });
}
function startCarousel() {
    $('.carousel').carousel({
        interval: 2500

    })
}
function ShowButton(id) {
    $(id).addClass("hidden-button-div-play");
}
function HideButton(id) {
    $(id).removeClass("hidden-button-div-play");
}
function NoFormReload() {
    $("#form").submit(function (e) {
        e.preventDefault();
    });
}

function UploadImages (dotNetObject) {
    var formData = new FormData();
    var fileInput = document.getElementById("files");
    if (fileInput.files.length == 0) {
        return;
    }
    for (i = 0; i < fileInput.files.length; i++) {
        formData.append('file', fileInput.files[i])
    }
    var xhr = new XMLHttpRequest();
    xhr.open('POST', 'api/Image/Upload');
    xhr.send(formData);
    xhr.onreadystatechange = function (evt) {
        if (xhr.readyState == XMLHttpRequest.DONE) {
            var obj = JSON.parse(xhr.responseText);
            dotNetObject.invokeMethodAsync('ReadListCallback', obj);
        }

    }
    ClearFileInput(fileInput);

}
function UploadImage(dotNetObject) {
    var formData = new FormData();
    var fileInput = document.getElementById("file");
    if (fileInput.files.length == 0) {
        return;
    }
    for (i = 0; i < fileInput.files.length; i++) {
        formData.append('file', fileInput.files[i])
    }
    var xhr = new XMLHttpRequest();
    xhr.open('POST', 'api/Image/Upload');
    xhr.send(formData);
    xhr.onreadystatechange = function (evt) {
        if (xhr.readyState == XMLHttpRequest.DONE) {
            var obj = JSON.parse(xhr.responseText);
            dotNetObject.invokeMethodAsync('ReadListCallback', obj);
        }

    }

    ClearFileInput(fileInput);

}

function ClearFileInput(f) {
    if (f.value) {
        try {
            f.value = '';
        }
        catch (err) {

        }
    }
}

function selectContactMethod(animateDown, animateUp) {
    $('#' + animateDown).addClass('Contact-Options-AnimationDown');
    $('#' + animateDown).addClass('h-auto');
    $('#' + animateUp).addClass('Contact-Options-AnimationUp');

}

function SetCookie(key, value, days) {
    var expires;
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        expires = "; expires=" + date.toUTCString();
    }
    else {
        expires = "";
    }
    document.cookie = encodeURIComponent(key) + "=" + encodeURIComponent(value) + expires + "; path=/";
}
function ReadCookie(name) {
    var nameEQ = encodeURIComponent(name) + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) === ' ')
            c = c.substring(1, c.length);
        if (c.indexOf(nameEQ === 0))
            return decodeURIComponent(c.substring(nameEQ.length, c.length));
    }
    return null;
}
function EraseCookie(name) {
    SetCookie(name, "", -1);
}