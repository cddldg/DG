class User {
    name: string = 'linkFly'

    say(myName: string): string {
        return `hello, ${myName}`
    }
}
let u = new User()
u.name = 'dfdfd'
console.log(u.say)