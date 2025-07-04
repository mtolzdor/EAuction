const config = {
  baseApiUrl: "https://localhost:4000",
};

const currencyFormatter = new Intl.NumberFormat("en-US", {
  style: "currency",
  currency: "USD",
  maximumFractionDigits: 2,
});

const toBase64 = (file: File): Promise<string> => {
  return new Promise((resolve, reject) => {
    const fileReader = new FileReader();
    fileReader.onload = () => resolve(fileReader.result as string);
    fileReader.onerror = () => reject();
    fileReader.readAsDataURL(file);
  });
};

export default config;
export { currencyFormatter, toBase64 };
