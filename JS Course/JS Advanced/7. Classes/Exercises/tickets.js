function solve(ticketDescription, sorting){
    let tickets = [];

    class Ticket{
        constructor(destination, price, status){
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    [...ticketDescription].map(ticket => {
        let data = ticket.split("|");
        tickets.push(new Ticket(data[0], Number(data[1]), data[2]))
        }
    );

    if (sorting === "price") {
        tickets = tickets.sort((a, b) => a.price - b.price);
    } else {
        tickets = tickets.sort((a, b) => a[sorting].localeCompare(b[sorting]));
    }

    return tickets;
}

console.log(solve(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'price'));