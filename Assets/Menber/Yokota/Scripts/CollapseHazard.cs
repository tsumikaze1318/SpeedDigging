using UniRx;
using UnityEngine;

namespace CollapseHazard
{
    public class CollapseHazardController : MonoBehaviour
    {
        private CollapseHazardPresenter _presenter;
        [SerializeField]
        private CollapseHazardView _view;

        private void Start()
        {
            CollapseHazardModel model = new CollapseHazardModel();
            _presenter = new CollapseHazardPresenter(model, _view);
        }

        public CollapseHazardPresenter GetPresenter() { return _presenter; }
        public void ResetPercentage()
        {
            _presenter.ResetPercentage();
        }

        public void UpdatePercentage()
        {
            _presenter.UpdatePercentage();
        }
    }
}

namespace CollapseHazard
{
    public class CollapseHazardModel
    {
        private const int PERCENTAGE_INCREASE = 10;
        private ReactiveProperty<float> _currentPercentageProperty = new ReactiveProperty<float>();
        public ReactiveProperty<float> CurrentPercentageProperty => _currentPercentageProperty;

        public void ResetPercentage()
        {
            _currentPercentageProperty.Value = 0;
        }

        public void UpdatePercentage()
        {
            _currentPercentageProperty.Value += PERCENTAGE_INCREASE;
        }
    }
}

namespace CollapseHazard
{
    public class CollapseHazardPresenter
    {
        private CollapseHazardModel _model;
        public CollapseHazardModel Model => _model;
        private CollapseHazardView _view;

        public CollapseHazardPresenter(CollapseHazardModel model, CollapseHazardView view)
        {
            _model = model;
            _view = view;

            _model.CurrentPercentageProperty.Subscribe(x => { _view.UpdatePercentageText(x); });
            _model.ResetPercentage();
        }

        public void UpdatePercentage()
        {
            _model.UpdatePercentage();
        }

        public void ResetPercentage()
        {
            _model.ResetPercentage();
        }
    }
}