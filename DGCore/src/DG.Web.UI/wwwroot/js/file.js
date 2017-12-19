var User = (function () {
    function User() {
        this.name = 'linkFly';
    }
    User.prototype.say = function (myName) {
        return "hello, " + myName;
    };
    return User;
}());
var u = new User();
u.name = 'dfdfd';
console.log(u.say);
