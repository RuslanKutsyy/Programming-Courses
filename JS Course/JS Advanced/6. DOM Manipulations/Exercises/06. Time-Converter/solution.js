function attachEventsListeners() {
    const listOfIDs = ["days", "hours","minutes", "seconds"];
    const timeCoef = {
        days: (x) => x/1,
        hours: (x) => x/24,
        minutes: (x) => x/1440,
        seconds: (x) => x/86400
    }
    const defaultTimeData = {
        days: 1,
        hours: 24,
        minutes: 1440,
        seconds: 86400
    }

    const idMapper = {
        daysBtn : "days",
        hoursBtn: "hours",
        minutesBtn: "minutes",
        secondsBtn: "seconds"
    }

    function updateHTML(originalID){
        let originalElementValue = document.getElementById(originalID).value;
        return listOfIDs.forEach(x => {
            if (x !== originalID) {
                document.getElementById(x).value = timeConverter(originalElementValue, originalID, x);
            }
        })
    }

    function timeConverter(originaTimeValue, originalUnits, requiredUnits) {
        let coef = timeCoef[originalUnits](originaTimeValue);
        let result = defaultTimeData[requiredUnits] * coef;
        return result < 1 ? Math.floor(result) : result;
    }

    function eventHandler(evt){
        if (evt.target.type == "button") {
            let sourceID = idMapper[evt.target.id];
            updateHTML(sourceID);
        }
    }    
    
    document.querySelector("main").addEventListener("click", function(e){
        eventHandler(e)
    })
}