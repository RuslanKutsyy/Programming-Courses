function solve() {
   let products = Array.from(document.getElementsByClassName("product"));
   let textArea = document.getElementsByTagName("textarea")[0];
   let checkOutButton = document.getElementsByClassName("checkout")[0];
   let shoppingCart = {};
   let stopShopping = false;

   products.forEach(product => product.getElementsByClassName("product-add")[0].addEventListener('click', function(){
      if (!stopShopping) {
         let productName = product.getElementsByClassName("product-title")[0].innerText;
         let productPrice = Number(product.getElementsByClassName("product-line-price")[0].innerText);
         if (!shoppingCart.hasOwnProperty(productName) && !stopShopping) {
         shoppingCart[productName] = productPrice;
         textArea.value += `Added ${productName} for ${productPrice.toFixed(2)} to the cart.\n`;
         } else if (shoppingCart.hasOwnProperty(productName) && !stopShopping) {
         textArea.value += `Added ${productName} for ${productPrice.toFixed(2)} to the cart.\n`;
         shoppingCart[productName] += productPrice;
         }
      }
   }));

   checkOutButton.addEventListener('click', function(){
      if (!stopShopping) {
         let totalMoney = 0;
         Object.keys(shoppingCart).forEach(x => totalMoney += shoppingCart[x]);
         textArea.value += `You bought ${Object.keys(shoppingCart).join(', ')} for ${totalMoney.toFixed(2)}.`;
         stopShopping = true;
      }
   })
}