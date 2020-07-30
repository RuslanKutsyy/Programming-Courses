function solve() {
    const sections = document.querySelectorAll("section");
    const openSection = sections.item(1).querySelectorAll("div").item(1);
    const inProgSection = sections.item(2).querySelectorAll("div").item(1);
    const completeSection = sections.item(3).querySelectorAll("div").item(1);
    
    const taskTitle = document.getElementById("task");
    const taskDescription = document.getElementById("description");
    const taskDueDate = document.getElementById("date");


    document.querySelector("#add").addEventListener("click", addTask);

    function createNewTask() {
        let task = document.createElement("article");
        task.innerHTML =
        `<h3>${taskTitle}</h3>
        <p>${taskDescription}</p>
        <p>${taskDueDate}</p>
        <div>
            <button class = "green">Start</button>
            <button class = "red">Delete</button>
        </div>`;

        return task;
    }

    function addTask(e){
        e.preventDefault();

        if (taskTitle.value !== "" && taskDescription.value !== "" && taskDueDate.value !== "") {
            let article = createNewTask();
            openSection.appendChild(article);
        }
    }
}