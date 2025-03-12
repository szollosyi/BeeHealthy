import React from 'react';
import { render, screen, fireEvent, waitFor } from '@testing-library/react';
import { Login } from './Login';
import '@testing-library/jest-dom';
import axios from 'axios';

jest.mock('axios');

describe('Login komponens', () => {
  test('ki kellene renderelni a usernév és a jelszó mezőket', () => {
    render(<Login />);
    expect(screen.getByPlaceholderText('Felhasználónév')).toBeInTheDocument();
    expect(screen.getByPlaceholderText('Jelszó')).toBeInTheDocument();
  });

  test('engedélyeznie kell a űrlapmezők bevitelét', () => {
    render(<Login />);
  
    const usernameInput = screen.getByPlaceholderText('Felhasználónév');
    const passwordInput = screen.getByPlaceholderText('Jelszó');
  
    fireEvent.change(usernameInput, { target: { value: 'admin' } });
    fireEvent.change(passwordInput, { target: { value: 'admin' } });
  
    expect(usernameInput.value).toBe('admin');
    expect(passwordInput.value).toBe('admin');
  });

  test('meg kell hívnia a bejelentkezési API-t gombnyomásra', async () => {
    axios.post.mockImplementation((url) => {
      if (url.includes('/api/Login/SaltRequest/')) {
        return Promise.resolve({ data: 'random_salt' });
      }
      if (url.includes('/api/Login')) {
        return Promise.resolve({
          status: 200,
          data: { name: 'Admin Felhasználó', profilePicturePath: '/avatar.png' }
        });
      }
      return Promise.reject(new Error('Ismeretlen API hívás'));
    });

    render(<Login />);

    const usernameInput = screen.getByPlaceholderText('Felhasználónév');
    const passwordInput = screen.getByPlaceholderText('Jelszó');
    const loginButton = screen.getByRole('button', { name: 'Bejelentkezés' }); // 🔥 Ezt javítottam

    fireEvent.change(usernameInput, { target: { value: 'admin' } });
    fireEvent.change(passwordInput, { target: { value: 'admin' } });

    fireEvent.click(loginButton);

    // Várunk az aszinkron műveletekre
    await waitFor(() => expect(axios.post).toHaveBeenCalledTimes(2));
    await waitFor(() => expect(localStorage.getItem('felhasz')).not.toBeNull());
  });
});
