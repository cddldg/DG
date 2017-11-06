layui.define('jquery', function (exports) { 
    var $ = layui.$;
    var obj = {
        gettoken: function () {
            var tokenss;
            $.ajax({
                type: 'POST',
                url: '/api/token',
                async: false,
                data: {
                    "username": "admin"
                    , "password": "111111"
                }
            }).done(function (data, statusText, xhdr) {
                tokenss = 'Bearer ' + data.access_token;
            }).fail(function (xhdr, statusText, errorText) {

            });
            return tokenss;
        }
    };

    exports('token', obj);
}); 