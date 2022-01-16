module.exports = {
  content: ["./index.html", "./src/**/*.{vue,js,ts,jsx,tsx}"],
  theme: {
    fontFamily: {
      sans: ["Inter"],
    },
    colors: {
      transparent: "transparent",
      black: "#1C1C1C",
      white: "#FFFFFF",
      green: {
        300: "#29A98B",
        500: "#279E80",
        700: "#249378",
      },
      red: {
        300: "#FF5256",
      },
      gray: {
        300: "#F9F9F9",
        500: "#F0F0F0",
        700: "#D0CECE",
        900: "#7B7B7B",
      },
    },
  },
  plugins: [],
};
