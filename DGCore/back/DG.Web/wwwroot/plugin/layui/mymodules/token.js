/*
*layui添加token模块
*/
layui.define('jquery', function (exports) { 
    var $ = layui.$;
    var obj = {
        gettoken: function () {
            var tokens;
            $.ajax({
                type: 'POST',
                url: '/api/token',
                async: false,
                data: {
                    "username": "admin"
                    , "password": "123456"
                }
            }).done(function (data, statusText, xhdr) {
                if (data && data.IsError == 0) {
                    tokens = data.Data.Token_Type + ' ' + data.Data.Access_Token;
                } else {
                    tokens = data.ErrorMessage;
                }
                
            }).fail(function (xhdr, statusText, errorText) {

            });
            return tokens;
        }
    };
    exports('token', obj);
}); 