const routes = {
    "home": "home-template",
    "login": "login-form-template",
    "register": "register-form-template",
    "add-movie": "add-movie-template",
    "details": "movie-details-template",
};

const router = async (fullPath) => {
    let [path, id] = fullPath.split('/');
    let app = document.getElementById("app");
    let templateData = authService.getData();

    switch (path){
        case "home":
            templateData.movies = await movieService.getAll();
            break;
        case 'logout':
            authService.logout();
            let interval = setInterval(function (){
                clearInterval(interval);
                navigate("home");
            }, 1000);
            return;

        case "details":
            let movieDetails = await movieService.getMovie(id);
            Object.assign(templateData, movieDetails);
            break;
        default:
            break;
    }

    let templateId = routes[path];

    let template = Handlebars.compile(document.getElementById(templateId).innerHTML);

    app.innerHTML = template(templateData);
};