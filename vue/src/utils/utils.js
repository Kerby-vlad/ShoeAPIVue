const ROOT = "http://localhost:5000/";

export const utils = {
  API: {
    BRANDS: `${ROOT}api/brands/`,
    SHOES:`${ROOT}api/shoes/`
  },
  PHOTO_URL: `${ROOT}photos/`,
  CloseModal(type, model) {
    document.querySelector(`#${type}${model}Modal`).classList.remove("show");
    document.querySelector(`#${type}${model}Modal`).setAttribute("style", "display: none");
    document.querySelector(`#${type}${model}Modal`).removeAttribute("aria-modal");
    document.querySelector(".modal-backdrop").remove();
    document.querySelector("body").classList.remove("modal-open");
    document.querySelector("body").removeAttribute("style");
  },
  ToValidDate(date){
    let day = date.substring(0,2);
    let month = date.substring(3,5);
    let year = date.substring(6, date.length);
    return `${month}-${day}-${year}`;
  }
}
