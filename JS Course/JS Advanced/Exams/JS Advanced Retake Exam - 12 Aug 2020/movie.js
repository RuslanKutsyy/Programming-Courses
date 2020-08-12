class Movie {
    constructor(movieName, ticketPrice) {
        this.movieName = movieName;
        this.ticketPrice = Number(ticketPrice);
        this.screenings = [];
        this.screeningProfit = 0;
        this.soldTickets = 0;
    }

    newScreening(date, hall, description){
        let existingScreening = this.screenings.findIndex(x => x.date === date
        && x.hall === hall);

        if (existingScreening >= 0){
            throw new Error(`Sorry, ${hall} hall is not available on ${date}`);
        }

        this.screenings.push({
            date: date,
            hall: hall,
            description: description
        });

        return `New screening of ${this.movieName} is added.`
    }

    endScreening(date, hall, soldTickets){
        let existingScreening = this.screenings.findIndex(x => x.date === date
            && x.hall === hall);

        if (existingScreening < 0){
            throw new Error(`Sorry, there is no such screening for ${this.movieName} movie.`);
        }

        let currentScreeningProfit = this.ticketPrice * soldTickets;
        this.screeningProfit += currentScreeningProfit;
        this.soldTickets += soldTickets;
        this.screenings.splice(existingScreening, 1);

        return `${this.movieName} movie screening on ${date} in ${hall} hall has ended. Screening profit: ${currentScreeningProfit}`;
    }

    toString (){
        let result = `${this.movieName} full information:\n`;
        result += `Total profit: ${this.screeningProfit.toFixed(0)}$\nSold Tickets: ${this.soldTickets}\n`;

        if (this.screenings.length > 0){
            result += "Remaining film screenings:";
            this.screenings.sort(function(a, b) {
                return a.hall.toLowerCase().localeCompare(b.hall.toLowerCase());
            }).forEach(x => result += `\n${x.hall} - ${x.date} - ${x.description}`);
        } else {
            result += "No more screenings!";
        }

        return result;
    }
}

let m = new Movie('Wonder Woman 1984', '10.00');
console.log(m.newScreening('October 2, 2020', 'IMAX 3D', `3D`));
console.log(m.newScreening('October 3, 2020', 'Main', `regular`));
console.log(m.newScreening('October 4, 2020', 'IMAX 3D', `3D`));
console.log(m.endScreening('October 2, 2020', 'IMAX 3D', 150));
console.log(m.endScreening('October 3, 2020', 'Main', 78));
console.log(m.toString());

m.newScreening('October 4, 2020', '235', `regular`);
m.newScreening('October 5, 2020', 'Main', `regular`);
m.newScreening('October 3, 2020', '235', `regular`);
m.newScreening('October 4, 2020', 'Main', `regular`);
console.log(m.toString());