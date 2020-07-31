function solve() {
    const sections = document.querySelectorAll("section");
    const openSection = sections.item(1).querySelectorAll("div").item(1);
    const inProgSection = sections.item(2).querySelectorAll("div").item(1);
    const completeSection = sections.item(3).querySelectorAll("div").item(1);
    
    const taskTitle = document.getElementById("task");
    const taskDescription = document.getElementById("description");
    const taskDueDate = document.getElementById("date");


    document.querySelector("#add").addEventListener("click", addTask);

    function addTask(e){
        e.preventDefault();

        if (taskTitle.value !== "" && taskDescription.value !== "" && taskDueDate.value !== "") {
            const btnStart = createEl("button", "start", {className: "green"});
            const btnDelete = createEl("button", "delete", {className: "red"});
            const btnFinish = createEl("button", "finish", {className: "orange"});
            
            const task = createEl("article", [
                createEl("h3", taskTitle.value)
            ])
        }
    }

    function createEl(type, content, attributes) {
        const el = document.createElement(type);

        if (attributes !== undefined) {
            Object.assign(el, attributes);
        }

        if (Array.isArray(content)) {
            content.forEach(append);
        } else {
            append(content);
        }

        function append(node) {
            if (typeof node === 'string') {
                node = document.createTextNode(node);
            }
            el.appendChild(node);
        }

        return el;
    }
}