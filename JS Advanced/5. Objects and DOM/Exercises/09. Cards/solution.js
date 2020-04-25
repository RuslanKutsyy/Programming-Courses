function solve() {
   let firstPlayerCards = Array.from(document.getElementById("player1Div").children);
   let secondPlayerCards = Array.from(document.getElementById("player2Div").children);
   let firstSpan = document.getElementById("result").children[0];
   let secondSpan = document.getElementById("result").children[2];
   let history = document.getElementById("history");
   let firstCardValue, secondCardValue;

   firstPlayerCards.forEach( card => card.addEventListener('click', cardsComparison));
   secondPlayerCards.forEach( card => card.addEventListener('click', cardsComparison));

   function cardsComparison() {
      if (event.target.parentElement.id === "player1Div") {
         firstCardValue = Number(event.target.getAttribute('name'));
         firstSpan.innerText = firstCardValue;
         event.target.src = "images/whiteCard.jpg";
      } else if (event.target.parentElement.id === "player2Div") {
         secondCardValue = Number(event.target.getAttribute('name'));
         secondSpan.innerText = secondCardValue;
         event.target.src = "images/whiteCard.jpg";
      }


      if (firstCardValue != undefined && secondCardValue != undefined) {
         let firstTarget = firstPlayerCards.find(x => x.getAttribute('name') === `${firstCardValue}`);
         let secondTarget = secondPlayerCards.find(x => x.getAttribute('name') === `${secondCardValue}`);

         if (firstCardValue > secondCardValue) {
            firstTarget.style.border = '2px solid green';
            secondTarget.style.border = '2px solid red';
            addToHistory(`[${firstCardValue} vs ${secondCardValue}]`);

         } else {
            firstTarget.style.border = '2px solid red';
            secondTarget.style.border = '2px solid green';
            let text = `[${firstCardValue} vs ${secondCardValue}]`;
            addToHistory(text);
         }
         firstCardValue = null;
         secondCardValue = null;
      }


      function addToHistory(text){
         history.innerHTML += text + "&nbsp";

         firstSpan.innerText = '';
         secondSpan.innerText = '';
      }
   }
}