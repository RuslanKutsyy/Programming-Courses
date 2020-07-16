(function(){

    let suits = {
        CLUBS: "\u2663",
        DIAMONDS: "\u2666",
        HEARTS: "\u2665",
        SPADES: "\u2660"
    };

    const faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];

    class Card{
        constructor(face, suit){
            this.face = face;
            this.suit = suit;
        }

        get face(){
            return this.face;
        }

        set face(face){
            if (!faces.includes(face)) {
                Throw(new Error("Invalid card face " + face));
            }
            this.face = face;
        }

        get suit(){
            return this.suit;
        }

        set suit(suit){
            if (Object.keys(Suits).map(k => Suits[k]).includes(suit)) {
                Throw(new Error("Invalid card suit " + suit));
            }
            this.suit = suit;
        }
    }
})