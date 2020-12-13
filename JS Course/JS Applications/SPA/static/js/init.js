function addEventListeners() {
    let navigationTemplate = Handlebars.compile(document.getElementById("navigation-template").innerHTML);
    let movieCardTemplate = Handlebars.compile(document.getElementById("movie-card-template").innerHTML);

    Handlebars.registerPartial("navigation-template", navigationTemplate);
    Handlebars.registerPartial("movie-card", movieCardTemplate);

    navigate("home");
}

function navigateHandler(e) {
    e.preventDefault();
    if (e.target.tagName.toLowerCase() != "a" && e.target.tagName.toLowerCase() != "button"){
        return;
    }
    let url = '';
    if (e.target.tagName.toLowerCase() == 'button' && e.target.id == "details-btn"){
        url = new URL(e.target.parentNode.href);
    } else {
        url = new URL(e.target.href);
    }

    navigate(url.pathname.slice(1));
}

function onLoginSubmit(e) {
    e.preventDefault();
    let formData = new FormData(document.forms.login);
    let email = formData.get("email");
    let password = formData.get("password");
    let appContainer = document.getElementById("app");

    authService.login(email, password).then(data => {
        let id = '';
        let message = '';
        let path = '';
        if (Boolean(data['error'])){
            id = "notification-error";
            message = data['error']['message'];
            path = "login";
        } else {
            id = "notification-success";
            message = "Logged in successfully";
            path = "home";
        }
        let template = Handlebars.compile(document.getElementById(id).innerHTML);
        appContainer.innerHTML = template({message: message});
        let interval = setInterval(function (){
            clearInterval(interval);
            navigate(path);
        }, 1000);
    });


}

function onRegisterSubmit(e) {
    e.preventDefault();
    let appContainer = document.getElementById("app");
    let formData = new FormData(document.forms.register);
    let email = formData.get("email");
    let password = formData.get("password")
    let repeatPassword = formData.get("repeatPassword");
    if (!(Boolean(email) && password.length >=6 && password === repeatPassword)){
        let successTemplate = Handlebars.compile(document.getElementById("notification-error").innerHTML);
        appContainer.innerHTML = successTemplate({message:"Invalid Email/Password."});
        let interval = setInterval(function (){
            clearInterval(interval);
            navigate("register");
        }, 1000);

        return;
    } else {
        authService.register(email, password).then(data => {
            let successTemplate = Handlebars.compile(document.getElementById("notification-success").innerHTML);
            appContainer.innerHTML = successTemplate({message: "Successful registration!"});
            let interval = setInterval(function (){
                clearInterval(interval);
                navigate("home");
            }, 1000);
        });
    }
}

function onAddMovieSubmit(e){
    e.preventDefault();
    let formData = new FormData(document.forms['add-movie-form']);
    let title = formData.get("title");
    let description = formData.get("description");
    let imageUrl = formData.get("imageUrl");

    movieService.add({
        title,
        description,
        imageUrl
    }).then(res => navigate("home"));
}

const navigate = (path) => {
    history.pushState({}, '', `http://localhost:3000/${path}`);
    router(path);
}

addEventListeners();