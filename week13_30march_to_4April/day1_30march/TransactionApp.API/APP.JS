const API_BASE = 'https://your-api.azurewebsites.net'; // ← update after deploy

// ── Login ──
const loginForm = document.getElementById('loginForm');
if (loginForm) {
  loginForm.addEventListener('submit', async (e) => {
    e.preventDefault();
    if (!validateLogin()) return;

    const btn     = document.getElementById('loginBtn');
    const btnText = document.getElementById('btnText');
    const spinner = document.getElementById('btnSpinner');
    const arrow   = btn.querySelector('.btn-arrow');

    btnText.textContent = 'Signing in…';
    btn.disabled = true;
    spinner?.classList.remove('hidden');
    arrow?.classList.add('hidden');

    try {
      const res = await fetch(`${API_BASE}/api/auth/login`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
          username: document.getElementById('username').value.trim(),
          password: document.getElementById('password').value
        })
      });
      if (!res.ok) throw new Error('Invalid username or password');
      const { token } = await res.json();
      localStorage.setItem('jwt', token);
      window.location.href = 'dashboard.html';
    } catch (err) {
      showBanner('errorBanner', err.message);
    } finally {
      btnText.textContent = 'Sign in';
      btn.disabled = false;
      spinner?.classList.add('hidden');
      arrow?.classList.remove('hidden');
    }
  });
}

function validateLogin() {
  let valid = true;
  const u = document.getElementById('username');
  const p = document.getElementById('password');
  clearErrors();
  if (!u?.value.trim()) { setError('usernameErr', u, 'Username is required'); valid = false; }
  if (p?.value.length < 6) { setError('passwordErr', p, 'Minimum 6 characters'); valid = false; }
  return valid;
}

// ── Dashboard ──
const txTable = document.getElementById('txTable');
if (txTable) {
  const token = localStorage.getItem('jwt');
  if (!token) { window.location.href = 'index.html'; }
  else { loadTransactions(token); }

  document.getElementById('logoutBtn')?.addEventListener('click', () => {
    localStorage.removeItem('jwt');
    window.location.href = 'index.html';
  });
}

async function loadTransactions(token) {
  try {
    const res = await fetch(`${API_BASE}/api/transactions`, {
      headers: { 'Authorization': `Bearer ${token}` }
    });
    if (res.status === 401) { window.location.href = 'index.html'; return; }
    if (!res.ok) throw new Error('Failed to load transactions');
    const transactions = await res.json();
    if (typeof window._storeTransactions === 'function') window._storeTransactions(transactions);
    renderTable(transactions);
  } catch (err) {
    document.getElementById('loadingState')?.classList.add('hidden');
    showBanner('errorState', err.message);
  }
}

function renderTable(transactions) {
  document.getElementById('loadingState')?.classList.add('hidden');
  const tableWrap  = document.getElementById('tableWrap');
  const emptyState = document.getElementById('emptyState');
  const tbody      = document.getElementById('txBody');

  if (!transactions?.length) {
    tableWrap?.classList.add('hidden');
    emptyState?.classList.remove('hidden');
    return;
  }
  emptyState?.classList.add('hidden');
  tableWrap?.classList.remove('hidden');

  tbody.innerHTML = transactions.map(t => {
    const isCredit = t.type.toLowerCase() === 'credit';
    const desc = t.description || (isCredit ? 'Credit received' : 'Debit payment');
    return `<tr>
      <td>${new Date(t.date).toLocaleDateString('en-IN', {day:'2-digit', month:'short', year:'numeric'})}</td>
      <td style="color:var(--ink)">${desc}</td>
      <td><span class="badge badge-${t.type.toLowerCase()}">${t.type}</span></td>
      <td class="col-right" style="color:${isCredit ? 'var(--green)' : 'var(--red)'}">
        ${isCredit ? '+' : '−'}₹${t.amount.toLocaleString('en-IN', {minimumFractionDigits:2})}
      </td>
    </tr>`;
  }).join('');
}

// ── Helpers ──
function setError(id, input, msg) {
  const el = document.getElementById(id);
  if (el) el.textContent = msg;
  input?.classList.add('invalid');
}
function clearErrors() {
  document.querySelectorAll('.field-error').forEach(el => el.textContent = '');
  document.querySelectorAll('.invalid').forEach(el => el.classList.remove('invalid'));
}
function showBanner(id, msg) {
  const el = document.getElementById(id);
  if (!el) return;
  el.textContent = msg;
  el.classList.remove('hidden');
}