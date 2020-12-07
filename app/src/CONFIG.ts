export const API_ROOT =
  process.env.NODE_ENV === "production"
    ? "https://pladat.azurewebsites.net"
    : "https://localhost:5001";
