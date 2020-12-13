const routes = {
    "home": "home-template",
    "login": "login-form-template",
    "register": "register-form-template",
};

const router = (path) => {
    let appEl = document.getElementById("app");

    let authData = authService.getData();

    let templateId = routes[path];

    switch (path){
        case 'logout':
            authService.logout();
            return navigate("home");
        default:
            break;
    }

    let template = Handlebars.compile(document.getElementById(templateId).innerHTML);

    appEl.innerHTML = template(authData);
};