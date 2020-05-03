function roadRadar(input) {
    let speed = Number(input.shift());
    let area = input.shift();
    let speedLimit;

    switch (area) {
        case 'motorway':
            speedLimit = 130;
            break;
        case 'interstate':
            speedLimit = 90;
            break;
        case 'city':
            speedLimit = 50;
            break;
        case 'residential':
            speedLimit = 20;
            break;
        default:
            break;
    }

    if (speed > speedLimit) {
        if (speed - speedLimit <= 20) {
            console.log('speeding');
        }
        if (speed - speedLimit > 20 && speed - speedLimit <= 40) {
            console.log('excessive speeding');            
        }
        if (speed - speedLimit > 40) {
            console.log('reckless driving');            
        }
    }
}

roadRadar([200, 'motorway']);