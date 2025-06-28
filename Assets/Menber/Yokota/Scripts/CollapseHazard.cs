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

        public void SetPillarEffect()
        {
            _presenter.SetPillarEffect();
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

        private ReactiveProperty<int> _pillarEffectNum = new ReactiveProperty<int>();
        public ReactiveProperty<int> PillarEffectNum => _pillarEffectNum;

        public void ResetPercentage()
        {
            _currentPercentageProperty.Value = 0;
        }

        public void UpdatePercentage()
        {
            if (_pillarEffectNum.Value > 0) 
            {
                _pillarEffectNum.Value--;
                return;
            }
            if (_currentPercentageProperty.Value >= 100) { return; }
            _currentPercentageProperty.Value += PERCENTAGE_INCREASE;
        }

        public void SetPillarNum()
        {
            _pillarEffectNum.Value = 3;
            _currentPercentageProperty.Value = 0;
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
            _model.PillarEffectNum.Subscribe(x => { _view.DisplayPillarIcon(x > 0); });
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

        public void SetPillarEffect()
        {
            _model.SetPillarNum();
        }
    }
}