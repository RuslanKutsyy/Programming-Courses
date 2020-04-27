function solve() {
   let firstPlayer = document.getElementById('player1Div');
   let secondPlayer = document.getElementById('player2Div');
   let result = document.getElementById('result').children;
   let history = document.getElementById('history');
   let firstPlayerCard = '';
   let secondPlayerCard = '';

   [firstPlayer, secondPlayer].map(player => player.addEventListener('click', function(e){
      if (e.target !== undefined) {
         compareValues(player, e);
      }
   }));

   function compareValues(player, e) {
      if (player === firstPlayer) {
         firstPlayerCard = e.target;
         result[0].textContent = e.target.name;
      } else {
         secondPlayerCard = e.target;
         result[2].textContent = e.target.name;
      }

      e.target.src = "images/whiteCard.jpg";

      if (result[0].textContent !== '' && result[2].textContent !== '') {
         if (Number(result[0].textContent) > Number(result[2].textContent)) {
            colorCards(firstPlayerCard, secondPlayerCard);
         } else {
            colorCards(secondPlayerCard, firstPlayerCard);
         }
         addToHistory();
         defaultSettings();
      }
   }
   function colorCards(card1, card2) {
      card1.style.border = "2px solid green";
      card2.style.border = "2px solid red";
   }

   function addToHistory() {
      history.textContent += `[${firstPlayerCard.name} vs ${secondPlayerCard.name}] `;
   }

   function defaultSettings() {
      firstPlayerCard = '';
      secondPlayerCard = '';
      result[0].textContent = '';
      result[2].textContent = '';
   }
}