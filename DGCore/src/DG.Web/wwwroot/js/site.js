/*
* site.js
* hym
* 20171102
*/
var site = {
    getToken: function () {
        var tokens;
        $.ajax({
            type: 'POST',
            url: '/api/token',
            async: false,
            data: {
                "username": "admin"
                , "password": "111111"
            }
        }).done(function (data, statusText, xhdr) {
            tokens = 'Bearer ' + data.access_token;
        }).fail(function (xhdr, statusText, errorText) {

        });
        return tokens;
    }
};