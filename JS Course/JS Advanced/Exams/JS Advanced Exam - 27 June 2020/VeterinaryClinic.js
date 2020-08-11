class VeterinaryClinic {
    totalProfit = 0;
    currentWorkload = 0;

    constructor(clinicName, capacity) {
        this.clinicName = clinicName;
        this.capacity = capacity;
        this.clients = [];
    }

    newCustomer(ownerName, petName, kind, procedures){
        if (this.clients.length < this.capacity){
            let clientIndex = this.clients.findIndex(x => x.ownerName === ownerName && x.petName === petName);
            if (clientIndex >= 0){
                if (this.clients[clientIndex].length() > 0){
                    throw new Error(`This pet is already registered under ${ ownerName } name! ${ petName } is on our lists, waiting for ${ this.clients.join(", ") }.`)
                }
            } else {
                this.clients.push(
                    {
                        "ownerName": ownerName,
                        "petName": petName,
                        "kind": kind,
                        "procedures": procedures
                    }
                )
                this.currentWorkload++;
                return `Welcome ${ petName }!`
            }
        }
        else {
            throw new Error("Sorry, we are not able to accept more patients!");
        }
    }

    onLeaving(ownerName, petName){
        if (this.clients.findIndex(x => x.ownerName === ownerName) < 0){
            throw new Error("Sorry, there is no such client!");
        }

        let pet = this.clients.filter(x => x.petName === petName);
        let petIndex = pet.findIndex(x => x.ownerName === ownerName);

        if (petIndex < 0 || petIndex >= 0 && this.clients[petIndex].procedures.length === 0){
            throw new Error("Sorry, there are no procedures for { petName }!");
        }
        else {
            this.totalProfit += this.clients[petIndex].procedures.length * 500;
            this.clients[petIndex].procedures = [];
            this.currentWorkload -= 1;
        }
        return `Goodbye ${ petName }. Stay safe!`;
    }

    toString(){
        //ToDo..
    }
}