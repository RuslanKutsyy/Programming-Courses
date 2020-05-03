function stopwatch() {
    let startButton = document.getElementById('startBtn');
    let stopButton = document.getElementById('stopBtn');
    let textDiv = document.getElementById('time');
    let time;

    startButton.addEventListener('click', starTimer);

    stopButton.addEventListener('click', stopTimer);

    function starTimer() {
        startButton.disabled = true;
        stopButton.disabled = false;
        let seconds = 0;
        time = setInterval(secondCounter, 1000);
        textDiv.textContent = '00:00';
        
        function secondCounter() {
            seconds++;
            let minutes = Math.floor(seconds/60);
            let secs = Math.floor(seconds%60);
            
            textDiv.textContent = `${('0' + minutes).slice(-2)}:${('0' + secs).slice(-2)}`;
        }
    }

    function stopTimer() {
        startButton.disabled = false;
        stopButton.disabled = true;
        clearInterval(time);
    }
}