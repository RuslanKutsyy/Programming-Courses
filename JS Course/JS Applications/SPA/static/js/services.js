const apiKey = "AIzaSyBA38xx5Oz-EJXtEZ79eyILFUuVeMjz9UE";
const databaseUrl = "https://movies-b6c9b-default-rtdb.firebaseio.com";

const request = async (url, method = "GET", body) => {
    let options = {
        method,
    };

    if (body){
        Object.assign(options, {
            headers: {
                "content-type": "application/json"
            },
            body: JSON.stringify(body)
        });
    }

    let response = await fetch(url, options);

    let data = await response.json();

    return data;
}

const authService = {
    async login(username, password){
        let data = await request(`https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=${apiKey}`, "POST",
            {"email": username,
                "password": password,
                "returnSecureToken": true});
        if (!Boolean(data['error'])){
            localStorage.setItem("auth", JSON.stringify(data));
        }

        return data;
    },

    getData(){
        try {
            let data = JSON.parse(localStorage.getItem("auth"));

            return {
                isAuthenticated: Boolean(data.idToken),
                email: data.email || ''
            }
        } catch (error) {
            return {
                isAuthenticated: false,
                email: ''
            }
        }
    },

    logout(){
        localStorage.setItem("auth", '');
        let logoutTemplate = Handlebars.compile(document.getElementById("notification-success").innerHTML);
        document.getElementById("app").innerHTML = logoutTemplate({message: "Successful logout"});
    },

    async register(username, password){
        let data = await request(`https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=${apiKey}`,
            "POST",
            {"email": username,
                "password": password,
                "returnSecureToken": true});

        localStorage.setItem("auth", JSON.stringify(data));
        return data;
    }
}

const movieService = {
    async add(movieData){
        let res = await request(`${databaseUrl}/movies.json`, "POST", movieData);

        return res;
    },

    async getAll(){
        let res = await request(`${databaseUrl}/movies.json`, "GET");
        return Object.keys(res).map(key => ({key, ...res[key]}));
    },

    async getMovie(id){
        let res = await request(`${databaseUrl}/movies/${id}.json`, "GET");
        return res;
    }
}