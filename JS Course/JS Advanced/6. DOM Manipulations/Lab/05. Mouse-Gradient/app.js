function attachGradientEvents() {
    let gradientBox = document.getElementById('gradient');
    let result = document.getElementById('result');

    gradientBox.addEventListener('mousemove', function(e){
        let xOffset = e.offsetX;
        console.log(xOffset);
        let resultText = Math.floor(xOffset/e.target.clientWidth * 100);
        result.innerText = resultText + '%';
    });

    gradientBox.addEventListener('mouseout', function(e){
        result.innerText = '';
    });
}