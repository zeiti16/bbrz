$(document).ready(function () {
    $.validate({
        form: '#loginForm',
        showErrorDialogs: false,
        borderColorOnError: 'red',
        onSuccess: function ($form) {
            UserEinloggen();
        },
        onElementValidate: function (valid, $el, $form, errorMess) {
            if (!valid) {
                $el.prev().css("color", "red");
            } else {
                $el.prev().css("color", "#BBBBBB");
            }
        }
    });
})

function UserEinloggen() {
    $check = false;
    if ($('#SessionOrCookie').is(':checked')) {
        $check = true;
    }
    $.post("../User/Login/", {
        email: $('#userEmailLog').val(),
        password: $('#userPasswordLog').val(),
        angemeldetBleiben: $check
    }, function (daten) {
        if (daten == "true") {
            location.reload();
        } else {
            $("#loginForm label").css("color", "red");
            $("#loginForm input[type='text'],#loginForm input[type='password']").css("border", "1px solid red");
        }
    });
}

$(document).ready(function () {
    $.validate({
        form: '#registrierungForm',
        modules: 'security',
        showErrorDialogs: false,
        borderColorOnError: 'red',
        onSuccess: function ($form) {
            UserRegistrierung();
        },
        onElementValidate: function (valid, $el, $form, errorMess) {
            if (!valid) {
                $el.prev().css("color", "red");
            } else {
                $el.prev().css("color", "#BBBBBB");
            }
        }
    });
})

function UserRegistrierung() {
    $.post("../User/Registrierung/", {
        Vorname: $('#VornameReg').val(),
        Nachname: $('#NachnameReg').val(),
        email: $('#EmailReg').val(),
        password: $('#PwReg').val()
    }, function (daten) {
        if (daten == "true") {
            location.reload();
        } else {
            $("#registrierungForm label").css("color", "red");
            $("#registrierungForm input[type='text'],#registrierungForm input[type='password']").css("border", "1px solid red");
        }
    });
}