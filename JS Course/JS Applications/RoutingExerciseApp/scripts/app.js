const app = Sammy("#main", function (){
    this.get("/home", function (){
        this.partial("../templates/home/home.hbs");
    });
});

(() => {
    app.run("/home");
})();