function solveClasses () {
    class Hall {
        constructor(capacity, name) {
            this.capacity = capacity;
            this.name = name;
            this.events = [];
        }

        hallEvent(title){
            if (this.events.includes(title)){
                throw new Error("This event is already added!");
            }
            this.events.push(title);
            return "Event is added.";
        }

        close(){
            this.events = [];
            return `${this.name} hall is closed.`;
        }

        toString(){
            let textToReturn = `${this.name} hall - ${this.capacity}`;
            if (this.events.length > 0){
                textToReturn += "\n" + `Events: ${this.events.join(', ')}`;
            }
            return textToReturn;
        }
    }

    class MovieTheater extends Hall{
        constructor(capacity, name, screenSize) {
            super(capacity, name);
            this.screenSize = screenSize;
        }

        close() {
            return super.close() + "Аll screenings are over.";
        }

        toString() {
            return super.toString() + "\n" + `${this.name} is a movie theater with ${this.screenSize} screensize and ${this.capacity} seats capacity.`;
        }
    }
    
    
    class ConcertHall extends Hall{
        performers = [];
        constructor(capacity, name) {
            super(capacity, name);
        }

        hallEvent(title, performers) {
            if (this.events.includes(title)){
                throw new Error("This event is already added!");
            }

            this.events.push(title);
            this.performers.push(performers);

            return "Event is added.";
        }

        close() {
            return super.close() + "Аll performances are over.";
        }

        toString() {
            if (this.performers.length > 0){
                return super.toString() + "\n" + `Performers: ${this.performers.join(', ')}.`
            }
            return super.toString();
        }
    }

    return {
        Hall,
        MovieTheater,
        ConcertHall
    }
}