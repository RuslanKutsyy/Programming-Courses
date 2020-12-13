const apiKey = "AIzaSyBA38xx5Oz-EJXtEZ79eyILFUuVeMjz9UE";

const authService = {
    async login(username, password){
        let response = await fetch(`https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=${apiKey}`, {
            method: 'POST',
            headers: {
                "content-type": "application/json"
            },
            body: JSON.stringify({
                "email": username,
                "password": password,
                "returnSecureToken": true
            })
        });

        let data = await response.json();
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
    },

    async register(username, password){
        let response = await fetch(`https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=${apiKey}`, {
            method: 'POST',
            headers: {
                "content-type": "application/json"
            },
            body: JSON.stringify({
                "email": username,
                "password": password,
                "returnSecureToken": true
            })
        });

        let data = await response.json();

        localStorage.setItem("auth", JSON.stringify(data));
        return data;
    }
}