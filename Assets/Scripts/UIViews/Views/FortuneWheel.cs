using System.Collections;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;
using Random = UnityEngine.Random;

namespace UIViews.Views
{
    public class FortuneWheel : MonoBehaviour
    {
        [SerializeField] private Button StartButton;
        [SerializeField] private Transform rotationTransform;
        [SerializeField] private AnimationCurve animationCurve;

        [SerializeField] private int sectorCount = 7;
        [SerializeField] private float minSpeed = 2;
        [SerializeField] private float maxSpeed = 6;
        [SerializeField] private float duration = 6;
        [SerializeField] private int gamePrice = 200;
        private Session _session;

        [Inject]
        private void construct(Session session)
        {
            _session = session;
        }

        public bool dontHaveMoney;
        public int price;
        private bool canSpin;
        private int[] prices;

        public UnityEvent<int> OnResult { get; } = new UnityEvent<int>();
        public UnityEvent OnPlayerMoney { get; } = new UnityEvent();

        private void Start()
        {
            canSpin = true;
            dontHaveMoney = _session.User.UserGameNode.Node.Money <= 0;
            rotationTransform.rotation = Quaternion.Euler(Vector3.forward * Random.value * 360f);
            prices = new[]
            {
                50, -25, 20, 100, -50, 25, 200
            };
        }

        private void OnEnable()
        {
            StartButton.onClick.AddListener(Spin);
        }

        private void OnDisable()
        {
            StartButton.onClick.RemoveListener(Spin);
        }

        private void Spin()
        {
            if (dontHaveMoney || _session.User.UserGameNode.Node.Money < gamePrice)
            {
                canSpin = false;
                OnPlayerMoney?.Invoke();
                return;
            }

            if (!canSpin)
            {
                return;
            }

            canSpin = false;
            StartCoroutine(SpinTheWheel(duration));
        }

        private IEnumerator SpinTheWheel(float duration)
        {
            _session.User.UserGameNode.Node.SubtractMoney(gamePrice);
            var delta = 0.0f;
            while (delta < duration)
            {
                var t = delta / duration;
                var speed = Mathf.Lerp(minSpeed, maxSpeed, animationCurve.Evaluate(t));
                var deltaAngle = speed * Time.deltaTime;
                rotationTransform.Rotate(Vector3.forward, deltaAngle);
                delta += Time.deltaTime;
                yield return null;
            }

            var angle = rotationTransform.eulerAngles.z;
            var selectedIndex = (Mathf.RoundToInt((angle / 360f) * sectorCount - 1) + sectorCount) % sectorCount;
            angle = 360f * (selectedIndex + 1) / sectorCount;
            rotationTransform.rotation = Quaternion.Euler(Vector3.forward * angle);

            price = prices[selectedIndex];
            if (price > 0)
            {
                _session.User.UserGameNode.Node.AddMoney(price);
            }
            else
            {
                _session.User.UserGameNode.Node.SubtractMoney(price);
            }

            canSpin = true;
            OnResult?.Invoke(price);
            dontHaveMoney = _session.User.UserGameNode.Node.Money <= 0;
            Debug.LogError($"PlayerMoney: {_session.User.UserGameNode.Node.Money} - {dontHaveMoney}");
            
            _session.User.Update();
            // _accountController.UpdateMoney();
            // _accountController.UpdateUserInfo();
        }
    }
}