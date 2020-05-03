function architects(data){
    let name = data[0];
    let projectsNumber = Number(data[1]);
    let projectTime = 3;
    console.log(`The architect ${name} will need ${projectsNumber*projectTime} hours to complete ${projectsNumber} project/s.`);
}
architects(["George","4"]);