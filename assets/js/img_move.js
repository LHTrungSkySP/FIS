import * as def from "./defines.js"
const IMG_POS_X_MAX = def.IMG_POS_X_MAX;
const IMG_POS_X_MIN = def.IMG_POS_X_MIN;
const SPEED_IMG = def.SPEED_4
// Author: Lê hoàng trung 
// date: 12/11/2022 dd-mm-yy
// function: kéo ảnh từ bên trái sang bên phải
// input: tên ele cần kéo
export function drag_img_left_to_right(ele_name){
    var ele_img_meomeos = document.getElementsByClassName(ele_name);
    console.log(ele_name);
    for(let i=0;i<ele_img_meomeos.length;i++){
        setTimeout(changeImg(ele_img_meomeos[i],IMG_POS_X_MIN), 100);


    }
}
function changeImg(ele_img_meomeo,img_pos_x){
    return function(){
        if(img_pos_x<IMG_POS_X_MAX){
            img_pos_x+=SPEED_IMG;
            ele_img_meomeo.style.backgroundPositionX =img_pos_x + "px";
        }
        else if(img_pos_x>=IMG_POS_X_MAX){
            img_pos_x=IMG_POS_X_MIN+SPEED_IMG;
            ele_img_meomeo.style.backgroundPositionX=img_pos_x + "px";
        }
        setTimeout(changeImg(ele_img_meomeo,img_pos_x), 100);
    }
}