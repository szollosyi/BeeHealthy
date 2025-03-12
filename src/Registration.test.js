import React from "react";
import { render, screen, fireEvent } from "@testing-library/react";
import { Registratio } from "./Registration";
import '@testing-library/jest-dom';
jest.mock("react-router-dom", () => ({
  ...jest.requireActual("react-router-dom"),
  useNavigate: jest.fn(),
}));


describe("Registratio", () => {
  it("regisztrációs mezők renderelése", () => {
    render(  
        <Registratio />
    );
    expect(screen.getByPlaceholderText("Felhasználónév")).toBeInTheDocument();
    expect(screen.getByPlaceholderText("Teljes név")).toBeInTheDocument();
  });

  it("Űrlapmezők kitöltése", async () => {
    render(
        <Registratio />
    );
    
    const usernameInput = screen.getByPlaceholderText('Felhasználónév');
    const fullnameInput = screen.getByPlaceholderText('Teljes név');
    const emailInput = screen.getByPlaceholderText('E-mail');
    const pwdInput = screen.getByPlaceholderText('Jelszó');
    fireEvent.change(usernameInput, {
      target: { value: "testuser" },
    });
    fireEvent.change(fullnameInput, {
      target: { value: "Test User" },
    });
    fireEvent.change(emailInput, {
      target: { value: "test@example.com" },
    });
    fireEvent.change(pwdInput, {
      target: { value: "password123" },
    });
    expect(usernameInput.value).toBe('testuser');
   expect(fullnameInput.value).toBe('Test User');
   expect(emailInput.value).toBe('test@example.com');
   expect(pwdInput.value).toBe('password123');
  });

});
