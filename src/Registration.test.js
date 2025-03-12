import React from 'react';
import { render, screen, fireEvent, waitFor } from '@testing-library/react';
import { Registration } from './Registratio';
import '@testing-library/jest-dom';
import axios from 'axios';

jest.mock('axios');

describe('Registratio komponens', () => {
  test('ki kellene renderelni a regisztrációs űrlap mezőit', () => {
    render(<Registration />);
    expect(screen.getByPlaceholderText('Teljes név')).toBeInTheDocument();
    expect(screen.getByPlaceholderText('Felhasználónév')).toBeInTheDocument();
    expect(screen.getByPlaceholderText('E-mail')).toBeInTheDocument();
    expect(screen.getByPlaceholderText('Jelszó')).toBeInTheDocument();
  });

  test('engedélyeznie kell a űrlapmezők bevitelét', () => {
    render(<Registration />);

    const nameInput = screen.getByPlaceholderText('Teljes név');
    const usernameInput = screen.getByPlaceholderText('Felhasználónév');
    const emailInput = screen.getByPlaceholderText('E-mail');
    const passwordInput = screen.getByPlaceholderText('Jelszó');

    fireEvent.change(nameInput, { target: { value: 'Teszt Név' } });
    fireEvent.change(usernameInput, { target: { value: 'testuser' } });
    fireEvent.change(emailInput, { target: { value: 'test@example.com' } });
    fireEvent.change(passwordInput, { target: { value: 'password123' } });

    expect(nameInput.value).toBe('Teszt Név');
    expect(usernameInput.value).toBe('testuser');
    expect(emailInput.value).toBe('test@example.com');
    expect(passwordInput.value).toBe('password123');
  });

  test('meg kell hívnia a regisztrációs API-t gombnyomásra', async () => {
    axios.post.mockImplementation((url) => {
      if (url.includes('/api/Registry')) {
        return Promise.resolve({ data: 'Sikeres regisztráció!' });
      }
      return Promise.reject(new Error('Ismeretlen API hívás'));
    });

    render(<Registration />);

    const nameInput = screen.getByPlaceholderText('Teljes név');
    const usernameInput = screen.getByPlaceholderText('Felhasználónév');
    const emailInput = screen.getByPlaceholderText('E-mail');
    const passwordInput = screen.getByPlaceholderText('Jelszó');
    const registerButton = screen.getByRole('button', { name: 'Regisztráció' });

    fireEvent.change(nameInput, { target: { value: 'Teszt Név' } });
    fireEvent.change(usernameInput, { target: { value: 'testuser' } });
    fireEvent.change(emailInput, { target: { value: 'test@example.com' } });
    fireEvent.change(passwordInput, { target: { value: 'password123' } });

    fireEvent.click(registerButton);

    // Várunk az aszinkron műveletekre
    await waitFor(() => expect(axios.post).toHaveBeenCalledTimes(1));
    await waitFor(() => expect(axios.post).toHaveBeenCalledWith(
      'https://localhost:5001/api/Registry',
      expect.objectContaining({
        loginNev: 'testuser',
        Name: 'Teszt Név',
        email: 'test@example.com',
        hash: expect.any(String),
        salt: expect.any(String),
      })
    ));
  });
});
