function solve() {
   document.getElementById("send").addEventListener('click', onClickAction, false);

   function onClickAction(){
      let textInput = '';
      let textFromTextArea = document.getElementById("chat_input").value;
      textInput = document.createTextNode(textFromTextArea);
      let myChatMessages = document.getElementById("chat_messages");
      let newChatMessage = document.createElement("div");
      newChatMessage.className += "message my-message";
      newChatMessage.appendChild(textInput);
      myChatMessages.appendChild(newChatMessage);
      document.getElementById("chat_input").value = null;
   }
}