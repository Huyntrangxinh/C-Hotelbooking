(function () {
    const btn = document.getElementById('guestBtn');
    const panel = document.getElementById('guestPanel');
    const apply = document.getElementById('guestApply');
    const summary = document.getElementById('guestSummary');

    if (!btn || !panel) return;

    // Toggle
    btn.addEventListener('click', () => {
        panel.classList.toggle('d-none');
    });

    // Plus/minus
    panel.querySelectorAll('.counter').forEach(group => {
        const input = group.querySelector('input');
        const [minus, plus] = group.querySelectorAll('button');
        minus.addEventListener('click', () => {
            let v = parseInt(input.value || '0', 10);
            v = Math.max(group.dataset.target === 'adults' ? 1 : 0, v - 1);
            input.value = v;
        });
        plus.addEventListener('click', () => {
            let v = parseInt(input.value || '0', 10);
            input.value = v + 1;
        });
    });

    // Apply
    apply?.addEventListener('click', (e) => {
        e.preventDefault();
        const [adults, children, rooms] = Array.from(panel.querySelectorAll('.counter input')).map(i => parseInt(i.value || '0', 10));
        summary.textContent = `${adults} người lớn · ${children} trẻ em · ${rooms} phòng`;
        panel.classList.add('d-none');
    });

    // Đóng khi click ra ngoài
    document.addEventListener('click', (e) => {
        if (!panel.contains(e.target) && !btn.contains(e.target)) {
            panel.classList.add('d-none');
        }
    });
})();
