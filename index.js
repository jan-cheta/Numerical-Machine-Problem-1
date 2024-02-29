const inputTxtBx = document.getElementById("input-txtbx");
const choppingTxtBx = document.getElementById("chopping-txtbx");
const roundingTxtBx = document.getElementById("rounding-txtbx");
const convertBtn = document.getElementById("convert-btn");
const placeTxtBx = document.getElementById("place-txtbx");

convertBtn.addEventListener("click", ()=>{
    let placeNum = parseInt(placeTxtBx.value);
    let inputNum = inputTxtBx.value;
    let numSplit = inputNum.split(".")
    //chopping
    if(numSplit[1].length < placeNum){
        choppingTxtBx.value = inputNum;
    }else{
        choppingTxtBx.value = numSplit[0] + "." + numSplit[1].substring(0,placeNum);
    }

    //rounding
    let rounded = Math.round(parseFloat(inputNum)*(10**placeNum))/(10**placeNum);
    roundingTxtBx.value = rounded;
});
