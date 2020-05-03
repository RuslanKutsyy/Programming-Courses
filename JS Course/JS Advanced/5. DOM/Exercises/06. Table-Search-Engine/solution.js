function solve() {
   let tableRows = Array.from(document.querySelectorAll('tbody')[0].children);
   let searchButton = document.getElementById("searchBtn");
   let searchText = document.getElementById("searchField");

   searchButton.addEventListener('click', function(){
      let searchCriteria = searchText.value;
      for (let tableRow of tableRows) {
         if (tableRow.innerHTML.includes(searchCriteria)) {
            tableRow.className = 'select';
         }
      }
   });
}